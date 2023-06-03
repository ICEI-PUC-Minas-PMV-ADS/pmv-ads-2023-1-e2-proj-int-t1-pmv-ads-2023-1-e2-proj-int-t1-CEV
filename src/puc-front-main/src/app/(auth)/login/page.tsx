'use client';

import Card from '@/components/Card';
import {
  Box,
  Button,
  Container,
  Flex,
  FormControl,
  FormLabel,
  Heading,
  Input,
} from '@chakra-ui/react';
import Link from 'next/link';
import React from 'react';

const Login: React.FC = function () {
  return (
    <Flex
      bg="gray.100"
      minH="100vh"
      flexDir="column"
    >
      <Box p="24px">
        <Container maxW="container.lg" mt="16px">
          <Flex justifyContent="center" w="100%" pt="32px">
            <Card w="400px">
              <Heading mb="32px">Login</Heading>

              <form>
                <FormControl mb="16px">
                  <FormLabel>Email</FormLabel>
                  <Input type="email" />
                </FormControl>
                <FormControl mb="32px">
                  <FormLabel>Senha</FormLabel>
                  <Input type="password" />
                </FormControl>
                <Link href="/sales-report">
                  <Button colorScheme="blue" w="100%">Entrar</Button>
                </Link>
              </form>
            </Card>
          </Flex>
        </Container>
      </Box>
    </Flex>
  );
};

export default Login;
