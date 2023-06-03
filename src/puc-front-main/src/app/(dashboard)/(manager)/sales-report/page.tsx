/* eslint-disable guard-for-in */
/* eslint-disable no-restricted-syntax */

'use client';

import Card from '@/components/Card';
import {
  Box,
  Button,
  HStack,
  Input,
  Table, Tbody, Td, Th, Thead, Tr,
} from '@chakra-ui/react';
import React, { useEffect, useState } from 'react';

import {
  LineChart,
  Line,
  XAxis,
  CartesianGrid,
  Legend,
  ResponsiveContainer,
  YAxis,
  Tooltip,
} from 'recharts';
import moment from 'moment';
import { ISaleChart, ISaleItem } from '@/types';
import useSales from '../../(seller)/(sales)/(hooks)/use-sales';
import useProducts from '../products/(hooks)/use-products';

const Sales: React.FC = function () {
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');

  const { products } = useProducts();

  const { sales, filter } = useSales();

  const [filtering, setFiltering] = useState(false);
  const handleFilter = async (): Promise<void> => {
    setFiltering(true);
    await filter(startDate, endDate);
    setFiltering(false);
  };

  function calcularSomaProdutosPorData(vendas: ISaleItem[]): ISaleChart[] {
    const somaProdutosPorData: { [data: string]: number } = {};

    for (const venda of vendas) {
      const dataVenda = venda.dataVenda.split('T')[0];
      let somaProdutos = 0;

      for (const produto of venda.produtos) {
        somaProdutos += produto.produtoValor;
      }

      if (somaProdutosPorData[dataVenda]) {
        somaProdutosPorData[dataVenda] += somaProdutos;
      } else {
        somaProdutosPorData[dataVenda] = somaProdutos;
      }
    }

    const resultado: ISaleChart[] = [];

    for (const dataVenda in somaProdutosPorData) {
      resultado.push({
        dataVenda: moment(dataVenda).format('MM/DD/YYYY'),
        somaProdutos: somaProdutosPorData[dataVenda],
      });
    }

    return resultado;
  }

  const [chartData, setChartData] = useState<ISaleChart[]>([]);

  useEffect(() => {
    if (sales) {
      console.log('ache', calcularSomaProdutosPorData(sales));
      setChartData(calcularSomaProdutosPorData(sales));
    }
  }, [sales]);

  return (
    <Card
      title="Histórico de Vendas"
      action={(
        <HStack>
          <Input
            type="date"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
          />
          <Input
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
          />
          <Box>
            <Button
              colorScheme="blue"
              isLoading={filtering}
              onClick={handleFilter}
              isDisabled={!startDate || !endDate}
            >
              Filtrar
            </Button>
          </Box>
        </HStack>
      )}
    >
      <Box w="100%" h="300px" mb="32px">
        <ResponsiveContainer width="100%" height="100%">
          <LineChart
            width={500}
            height={300}
            data={chartData}
            margin={{
              top: 5,
              right: 30,
              left: 20,
              bottom: 5,
            }}
          >
            <CartesianGrid strokeDasharray="5 5" />
            <YAxis dataKey="somaProdutos" />
            <XAxis dataKey="dataVenda" />
            <Tooltip
              labelFormatter={(value) => `Data: ${value}`}
              formatter={
                (value) => `R$${parseFloat(value.toString()).toFixed(2).replace('.', ',')}`
              }
            />
            <Legend />
            <Line
              dataKey="somaProdutos"
              stroke="#005398"
              activeDot={{ r: 8 }}
              strokeWidth={2}
              dot={{ r: 4 }}
              name="Soma total"
            />
          </LineChart>
        </ResponsiveContainer>
      </Box>

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
