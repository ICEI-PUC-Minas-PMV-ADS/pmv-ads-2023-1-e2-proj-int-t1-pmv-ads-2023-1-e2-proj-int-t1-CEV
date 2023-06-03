'use client';

import { IUser, IUserForm } from '@/types';
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
} from '@chakra-ui/react';
import React, { useEffect, useState } from 'react';

interface Props {
  isOpen: boolean,
  onClose: () => void,
  submit: (form: IUserForm) => Promise<boolean>,
  isEdit?: boolean,
  user?: IUser | undefined
}

const CreateOrUpdateUserModal: React.FC<Props> = function ({
  isOpen,
  onClose,
  submit,
  isEdit,
  user,
}) {
  const [name, setName] = useState(user?.nome);

  useEffect(() => {
    if (user) { setName(user?.nome); }
  }, [user]);

  const [submiting, setSubmiting] = useState(false);
  const handleSubmit = async (): Promise<void> => {
    setSubmiting(true);
    if (name) {
      const success = await submit({ nome: name });
      if (success) { onClose(); }
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
              isEdit ? 'Editar Usuário'
                : 'Cadastrar Usuário'
            }
          </ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl mb="16px">
              <FormLabel>Nome</FormLabel>
              <Input value={name} onChange={(e) => setName(e.target.value)} />
            </FormControl>
            {/* <FormControl mb="16px">
              <FormLabel>Email</FormLabel>
              <Input type="email" />
            </FormControl>
            <FormControl mb="16px">
              <FormLabel>CPF</FormLabel>
              <Input />
            </FormControl>
            <FormControl mb="16px">
              <FormLabel>Cargo</FormLabel>
              <Select>
                <option>Gestor</option>
                <option>Estoquista</option>
                <option>Vendedor</option>
              </Select>
            </FormControl>
            <FormControl mb="16px">
              <FormLabel>Senha</FormLabel>
              <Input type="password" />
            </FormControl> */}
          </ModalBody>
          <ModalFooter>
            <Button
              onClick={onClose}
              mr="8px"
            >
              Cancelar
            </Button>
            <Button
              colorScheme="blue"
              isDisabled={!name}
              onClick={handleSubmit}
              isLoading={submiting}
            >
              Salvar
            </Button>
          </ModalFooter>
        </form>
      </ModalContent>
    </Modal>
  );
};

export default CreateOrUpdateUserModal;
