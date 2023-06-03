import { Box, HStack, Heading } from '@chakra-ui/react';
import React, { ReactElement, ReactNode } from 'react';

interface Props {
  w?: string,
  children: ReactNode,
  title?: string,
  action?: ReactElement
}

const Card: React.FC<Props> = function ({
  title, w, children, action,
}) {
  return (
    <Box w={w || '100%'} maxW="100%" p="24px" bg="white">
      {
        (title || action)
        && (
          <HStack justifyContent="space-between" mb="24px">
            {
              title
              && <Heading fontSize="18px">{title}</Heading>
            }
            {
              !!action && <Box>{action}</Box>
            }
          </HStack>
        )
      }
      {children}
    </Box>
  );
};

export default Card;
