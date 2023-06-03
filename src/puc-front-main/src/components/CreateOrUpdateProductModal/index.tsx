'use client';

import { IProduct, IProductForm } from '@/types';
import {
  Button,
  FormControl,
  FormLabel,
  Input,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  useToast,
} from '@chakra-ui/react';
import React, { useEffect, useState } from 'react';

interface Props {
  isOpen: boolean,
  onClose: () => void,
  submit: (form: IProductForm) => Promise<boolean>,
  isEdit?: boolean,
  product?: IProduct
}

const CreateOrUpdateProductModal: React.FC<Props> = function ({
  isOpen,
  onClose,
  submit,
  isEdit,
  product,
}) {
  const [name, setName] = useState('');
  const [value, setValue] = useState('');
  const [stock, setStock] = useState('');

  const [submiting, setSubmiting] = useState(false);

  const toast = useToast();

  useEffect(() => {
    if (product) {
      setName(product.descricao);
      setValue(product.valor.toString());
    }
  }, [product]);

  const handleSubmit = async (): Promise<void> => {
    if (!value) {
      toast({
        status: 'info',
        title: 'Informe um preço para o produto',
      });
      return;
    }
    if (!name) {
      toast({
        status: 'info',
        title: 'Informe uma descrição para o produto',
      });
      return;
    }
    if (!stock && !product) {
      toast({
        status: 'info',
        title: 'Informe um estoque inicial para o produto',
      });
      return;
    }
    setSubmiting(true);
    const success = await submit({
      valor: parseFloat(value),
      descricao: name,
      estoque: parseInt(stock, 10) || 0,
    });
    if (success) {
      onClose();
      setName('');
      setValue('');
      setStock('');
    }
    setSubmiting(false);
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <ModalOverlay />
      <ModalContent>
        <form>
          <ModalHeader>
            {
              isEdit ? 'Editar Produto'
                : 'Cadastrar Produto'
            }
          </ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl mb="16px">
              <FormLabel>Nome</FormLabel>
              <Input value={name} onChange={(e) => setName(e.target.value)} />
            </FormControl>
            <FormControl mb="16px">
              <FormLabel>Preço</FormLabel>
              <Input
                type="number"
                value={value}
                onChange={(e) => setValue(e.target.value)}
              />
            </FormControl>
            {
              !isEdit
              && (
                <FormControl mb="16px">
                  <FormLabel>Estoque inicial</FormLabel>
                  <Input
                    type="number"
                    value={stock}
                    onChange={(e) => setStock(e.target.value)}
                  />
                </FormControl>
              )
            }
          </ModalBody>
          <ModalFooter>
            <Button onClick={onClose} mr="8px">Cancelar</Button>
            <Button
              colorScheme="blue"
              isLoading={submiting}
              onClick={handleSubmit}
            >
              Salvar
            </Button>
          </ModalFooter>
        </form>
      </ModalContent>
    </Modal>
  );
};

export default CreateOrUpdateProductModal;
