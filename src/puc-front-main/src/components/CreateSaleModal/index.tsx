'use client';

import useProducts
  from '@/app/(dashboard)/(manager)/products/(hooks)/use-products';
import useUsers from '@/app/(dashboard)/(manager)/users/(hooks)/use-users';
import { IProduct, ISale } from '@/types';
import {
  Button,
  FormControl,
  FormLabel,
  HStack,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  Select,
  Table,
  Tbody,
  Td,
  Th,
  Thead,
  Tr,
} from '@chakra-ui/react';
import React, { useEffect, useState } from 'react';

interface Props {
  isOpen: boolean,
  onClose: () => void,
  submit: (sales: ISale[]) => Promise<boolean>,
}

const CreateSaleModal: React.FC<Props> = function ({
  isOpen,
  onClose,
  submit,
}) {
  const { products } = useProducts();
  const { users } = useUsers();

  const [sales, setSales] = useState<ISale[]>([]);
  const [selectedProduct, setSelectedProduct] = useState<IProduct>();
  const [selectedUser, setSelectedUser] = useState<string>();

  const remove = (index: number): void => {
    setSales((old) => old.filter((sale, i) => i !== index));
  };

  const add = (): void => {
    if (!selectedProduct) return;
    const user = users?.find((u) => u.id.toString() === selectedUser);
    if (!user) return;

    setSales((old) => [...old, { product: selectedProduct, user }]);
  };

  useEffect(() => {
    setSelectedProduct(undefined);
    setSales([]);
  }, [isOpen]);

  const [submiting, setSubmiting] = useState(false);
  const handleSubmit = async (): Promise<void> => {
    setSubmiting(true);
    const success = await submit(sales);
    if (success) {
      setSales([]);
      setSelectedProduct(undefined);
      setSelectedUser(undefined);
    }
    setSubmiting(false);
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <ModalOverlay />
      <ModalContent maxW="700px">
        <form>
          <ModalHeader>
            Nova Venda
          </ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl mb="24px">
              <FormLabel>Vendedor</FormLabel>
              <Select
                value={selectedUser}
                onChange={
                  (e) => setSelectedUser(e.target.value)
                }
                isDisabled={!!sales.length}
              >
                <option>Selecione</option>
                {
                  users?.map((user) => (
                    <option value={user.id}>
                      {user.nome}
                    </option>
                  ))
                }
              </Select>
            </FormControl>
            <HStack mb="16px">
              <FormControl>
                <FormLabel>Produto</FormLabel>
                <Select
                  value={selectedProduct?.id}
                  onChange={
                    (e) => setSelectedProduct(
                      products?.find((p) => p.id.toString() === e.target.value),
                    )
                  }
                >
                  <option>Selecione</option>
                  {
                    products?.map((product) => (
                      <option value={product.id}>
                        {product.descricao}
                        {' '}
                        -
                        {' R$'}
                        {product.valor.toFixed(2).replace('.', ',')}
                      </option>
                    ))
                  }
                </Select>
              </FormControl>
            </HStack>
            <Button
              colorScheme="blue"
              onClick={add}
              isDisabled={!selectedProduct || !selectedUser}
              w="100%"
              mb="32px"
            >
              Adicionar
            </Button>

            <Table mb="32px">
              <Thead>
                <Th>Produto</Th>
                <Th>Preço</Th>
                <Th>Vendedor</Th>
                <Th>Ações</Th>
              </Thead>
              <Tbody>
                {
                  sales.map((sale, index) => (
                    <Tr>
                      <Td>{sale.product.descricao}</Td>
                      <Td>
                        R$
                        {sale.product.valor.toFixed(2).replace('.', ',')}
                      </Td>
                      <Td>{sale.user.nome}</Td>
                      <Td>
                        <Button
                          colorScheme="red"
                          size="xs"
                          onClick={() => remove(index)}
                        >
                          Remover
                        </Button>
                      </Td>
                    </Tr>
                  ))
                }
              </Tbody>
            </Table>
          </ModalBody>
          <ModalFooter>
            <Button onClick={onClose} mr="8px">Cancelar</Button>
            <Button
              colorScheme="blue"
              onClick={handleSubmit}
              isLoading={submiting}
            >
              Finalizar Venda
            </Button>
          </ModalFooter>
        </form>
      </ModalContent>
    </Modal>
  );
};

export default CreateSaleModal;
