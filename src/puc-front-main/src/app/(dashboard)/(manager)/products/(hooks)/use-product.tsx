import useFetch, { api } from '@/hooks/use-fetch';
import { IProduct, IProductForm, IUseFetch } from '@/types';
import { useToast } from '@chakra-ui/react';

interface IUseProduct {
  product: IProduct | undefined,
  updateProduct: (form: IProductForm, productId?: string) => Promise<boolean>,
  updateStock: (qtd: number, productId?: string) => Promise<boolean>,
  removeProduct: (id: string) => Promise<boolean>
}

interface IFetch extends IUseFetch {
  data: IProduct | undefined
}

const useProduct = (id?: string): IUseProduct => {
  const { data: product, mutate }: IFetch = useFetch(
    id ? `/produto/${id}` : null,
  );
  const toast = useToast();

  const updateProduct = async (
    form: IProductForm,
    productId?: string,
  ): Promise<boolean> => {
    try {
      await api.patch(`/produto/${productId || id}`, {
        descricao: form.descricao,
        valor: form.valor,
      });
      await mutate();
      toast({
        status: 'success',
        title: 'Produto editado com sucesso',
      });
      return true;
    } catch (error) {
      toast({
        status: 'error',
        title: 'Algo de errado aconteceu',
      });
      return false;
    }
  };

  const updateStock = async (
    qtd: number,
    productId?: string,
  ): Promise<boolean> => {
    try {
      await api.patch(`/atualizar-estoque/${productId || id}`, {
        tipoAtualizacao: qtd > 0 ? 1 : 0,
        valor: qtd,
      });
      await mutate();
      toast({
        status: 'success',
        title: 'Entradas de estoque feitas com sucesso',
      });
      return true;
    } catch (error) {
      toast({
        status: 'error',
        title: 'Algo de errado aconteceu',
      });
      return false;
    }
  };

  const removeProduct = async (): Promise<boolean> => {
    try {
      await api.delete(`/produto/${id}`);
      await mutate();
      toast({
        status: 'success',
        title: 'Produto removido com sucesso',
      });
      return true;
    } catch (error) {
      toast({
        status: 'error',
        title: 'Algo de errado aconteceu',
      });
      return false;
    }
  };

  return {
    product,
    updateStock,
    updateProduct,
    removeProduct,
  };
};

export default useProduct;
