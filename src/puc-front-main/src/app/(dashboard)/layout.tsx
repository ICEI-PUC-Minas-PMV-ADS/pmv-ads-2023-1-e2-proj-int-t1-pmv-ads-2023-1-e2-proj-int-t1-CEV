'use client';

import Topbar from '@/components/Topbar';
import {
  Box, Container, Flex,
} from '@chakra-ui/react';
import React, { ReactElement } from 'react';

const RootLayout: React.FC<{ children: ReactElement }> = function ({
  children,
}) {
  return (
    <Flex
      bg="gray.100"
      minH="100vh"
      flexDir="column"
    >
      <Topbar />
      <Box p="24px">
        <Container maxW="container.lg" mt="16px">
          {children}
        </Container>
      </Box>
    </Flex>
  );
};

export default RootLayout;
