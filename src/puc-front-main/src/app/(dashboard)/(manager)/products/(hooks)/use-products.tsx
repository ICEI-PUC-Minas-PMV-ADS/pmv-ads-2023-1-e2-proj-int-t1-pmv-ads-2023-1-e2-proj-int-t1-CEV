import useFetch, { api } from '@/hooks/use-fetch';
import { IProduct, IProductForm, IUseFetch } from '@/types';
import { useToast } from '@chakra-ui/react';
import useProduct from './use-product';

interface IUseProducts {
  products: IProduct[] | undefined,
  createProduct: (form: IProductForm) => Promise<boolean>,
  removeProduct: (id: string) => Promise<boolean>,
  updateProduct: (id: string, form: IProductForm) => Promise<boolean>,
  updateStock: (id: string, qtd: number) => Promise<boolean>
}

interface IFetch extends IUseFetch {
  data: IProduct[] | undefined,
}

const useProducts = (): IUseProducts => {
  const { data: products, mutate }: IFetch = useFetch('/produto');
  const toast = useToast();

  const { updateProduct: onUpdate, updateStock: onUpdateStock } = useProduct();

  const createProduct = async (form: IProductForm): Promise<boolean> => {
    try {
      await api.post('/produto', form);
      await mutate();
      toast({
        status: 'success',
        title: 'Produto criado com sucesso',
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

  const removeProduct = async (id: string): Promise<boolean> => {
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

  const updateProduct = async (
    id: string,
    form: IProductForm,
  ): Promise<boolean> => {
    const success = await onUpdate(form, id);
    if (success) {
      await mutate();
    }

    return success;
  };

  const updateStock = async (
    id: string,
    qtd: number,
  ): Promise<boolean> => {
    const success = await onUpdateStock(qtd, id);
    if (success) {
      await mutate();
    }

    return success;
  };

  return {
    products,
    createProduct,
    removeProduct,
    updateProduct,
    updateStock,
  };
};

export default useProducts;
