import {
  Container, Flex, HStack, Link,
} from '@chakra-ui/react';
import React from 'react';
import NextLink from 'next/link';

const Topbar: React.FC = function () {
  return (
    <Flex bg="white" alignItems="center" h="60px">
      <Container maxW="container.lg">
        <HStack justifyContent="space-between">
          <HStack spacing="32px">
            <Link as={NextLink} href="/">Vendas</Link>
            <Link as={NextLink} href="/products">Produtos</Link>
            <Link as={NextLink} href="/users">Usuários</Link>
            <Link as={NextLink} href="/sales-report">Relatório de Vendas</Link>
            <Link as={NextLink} href="/stock">Estoque</Link>
          </HStack>
          <Link as={NextLink} href="/login">Sair</Link>
        </HStack>
      </Container>
    </Flex>
  );
};

export default Topbar;
