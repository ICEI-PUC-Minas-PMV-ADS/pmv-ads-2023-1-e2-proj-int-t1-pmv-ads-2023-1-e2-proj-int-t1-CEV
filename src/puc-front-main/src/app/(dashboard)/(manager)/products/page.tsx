'use client';

import Card from '@/components/Card';
import CreateOrUpdateProductModal from '@/components/CreateOrUpdateProductModal';
import {
  Box,
  Button,
  HStack,
  Table, Tbody, Td, Th, Thead, Tr, useDisclosure,
} from '@chakra-ui/react';
import React, { useState } from 'react';
import { IProduct } from '@/types';
import useProducts from './(hooks)/use-products';

const Products: React.FC = function () {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const {
    isOpen: createIsOpen,
    onOpen: createOnOpen,
    onClose: createOnClose,
  } = useDisclosure();

  const {
    products, removeProduct, createProduct, updateProduct,
  } = useProducts();

  const [activeProduct, setActiveProduct] = useState<IProduct>();
  const [removingId, setRemovingId] = useState<string>();
  const handleRemove = async (id: string): Promise<void> => {
    setRemovingId(id);
    await removeProduct(id);
    setRemovingId(undefined);
  };

  const handleOpenEdit = (product: IProduct): void => {
    setActiveProduct(product);
    onOpen();
  };

  return (
    <Card
      title="Produtos"
      action={(
        <Button
          colorScheme="blue"
          onClick={createOnOpen}
        >
          Cadastrar Produto
        </Button>
      )}
    >
      <Box maxW="100%" overflow="auto">
        <Table>
          <Thead>
            <Th>Nome</Th>
            <Th>Preço</Th>
            <Th>Ações</Th>
          </Thead>
          <Tbody>
            {
              products?.map((product) => (
                <Tr key={product.id}>
                  <Td>{product.descricao}</Td>
                  <Td>
                    R$
                    {product.valor.toFixed(2).replace('.', ',')}
                  </Td>
                  <Td>
                    <HStack>
                      <Button
                        size="xs"
                        colorScheme="blue"
                        onClick={() => handleOpenEdit(product)}
                      >
                        Editar
                      </Button>
                      <Button
                        size="xs"
                        colorScheme="red"
                        onClick={() => handleRemove(product.id as string)}
                        isLoading={!!removingId}
                      >
                        Remover
                      </Button>
                    </HStack>
                  </Td>
                </Tr>
              ))
            }
          </Tbody>
        </Table>
      </Box>

      {
        activeProduct
        && (
          <CreateOrUpdateProductModal
            isEdit
            isOpen={isOpen}
            onClose={onClose}
            submit={(data) => updateProduct(activeProduct.id as string, data)}
            product={activeProduct}
          />
        )
      }

      <CreateOrUpdateProductModal
        isOpen={createIsOpen}
        onClose={createOnClose}
        submit={createProduct}
      />
    </Card>
  );
};

export default Products;
