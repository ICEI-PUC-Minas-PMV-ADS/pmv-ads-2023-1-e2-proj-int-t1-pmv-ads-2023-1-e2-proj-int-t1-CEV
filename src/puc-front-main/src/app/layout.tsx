'use client';

import { ChakraProvider } from '@chakra-ui/react';
import React, { ReactElement } from 'react';

const RootLayout: React.FC<{ children: ReactElement }> = function ({
  children,
}) {
  return (
    <html lang="pt-BR">
      <head>
        <title>Controle de Estoque e Vendas</title>
      </head>
      <body>
        <ChakraProvider>
          {children}
        </ChakraProvider>
      </body>
    </html>
  );
};

export default RootLayout;
