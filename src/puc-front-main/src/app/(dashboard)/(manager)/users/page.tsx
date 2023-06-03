'use client';

import Card from '@/components/Card';
import CreateOrUpdateUserModal from '@/components/CreateOrUpdateUserModal';
import {
  Box,
  Button,
  HStack,
  Table, Tbody, Td, Th, Thead, Tr, useDisclosure,
} from '@chakra-ui/react';
import React, { useState } from 'react';
import { IUser } from '@/types';
import useUsers from './(hooks)/use-users';

const Users: React.FC = function () {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const {
    isOpen: createIsOpen,
    onOpen: createOnOpen,
    onClose: createOnClose,
  } = useDisclosure();

  const {
    users, createUser, updateUser, removeUser,
  } = useUsers();
  const [selectedUser, setSelectedUser] = useState<IUser>();

  const [removing, setRemoving] = useState<number>();
  const handleRemove = async (id: number): Promise<void> => {
    setRemoving(id);
    await removeUser(id.toString());
    setRemoving(undefined);
  };

  return (
    <Card
      title="Usuários"
      action={(
        <Button
          colorScheme="blue"
          onClick={createOnOpen}
        >
          Cadastrar Usuário
        </Button>
      )}
    >
      <Box maxW="100%" overflow="auto">
        <Table>
          <Thead>
            <Th>Nome</Th>
            <Th>Ações</Th>
          </Thead>
          <Tbody>
            {
              users?.map((user) => (
                <Tr key={user.id}>
                  <Td>{user.nome}</Td>
                  <Td>
                    <HStack>
                      <Button
                        size="xs"
                        colorScheme="blue"
                        onClick={() => {
                          setSelectedUser(user);
                          onOpen();
                        }}
                      >
                        Editar
                      </Button>
                      <Button
                        size="xs"
                        colorScheme="red"
                        isLoading={removing === user.id}
                        onClick={() => handleRemove(user.id)}
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
        selectedUser
        && (
          <CreateOrUpdateUserModal
            isEdit
            isOpen={isOpen}
            onClose={onClose}
            submit={(form) => updateUser(selectedUser.id.toString(), form)}
            user={selectedUser}
          />
        )
      }
      <CreateOrUpdateUserModal
        isOpen={createIsOpen}
        onClose={createOnClose}
        submit={createUser}
      />
    </Card>
  );
};

export default Users;
