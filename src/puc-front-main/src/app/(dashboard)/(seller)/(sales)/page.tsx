'use client';

import Card from '@/components/Card';
import CreateSaleModal from '@/components/CreateSaleModal';
import {
  Box,
  Button,
  Table, Tbody, Td, Th, Thead, Tr, useDisclosure,
} from '@chakra-ui/react';
import React from 'react';
import moment from 'moment';
import useSales from './(hooks)/use-sales';
import useProducts from '../../(manager)/products/(hooks)/use-products';

const Sales: React.FC = function () {
  const { sales, createSale } = useSales();
  const { products } = useProducts();

  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <Card
      title="Vendas"
      action={(
        <Button colorScheme="blue" onClick={onOpen}>Cadastrar venda</Button>
      )}
    >
      <CreateSaleModal
        isOpen={isOpen}
        onClose={onClose}
        submit={createSale}
      />
      <Box maxW="100%" overflow="auto">
        <Table>
          <Thead>
            <Th>Produto</Th>
            <Th>Valor</Th>
            <Th>Vendedor</Th>
            <Th>Data</Th>
          </Thead>
          <Tbody>
            {
              sales?.map((sale) => (
                sale.produtos.map((product) => (
                  <Tr key={`${product.produtoId}-${sale.id}`}>
                    <Td>
                      {
                        products?.find(
                          (p) => p.id === product.produtoId,
                        )?.descricao
                      }
                    </Td>
                    <Td>{product.produtoValor}</Td>
                    <Td>{sale.vendedor.nome}</Td>
                    <Td>
                      {
                        moment(sale.dataVenda).format('MM/DD/YYYY [-] HH:mm')
                      }

                    </Td>
                  </Tr>
                ))
              ))
            }
          </Tbody>
        </Table>
      </Box>
    </Card>
  );
};

export default Sales;
