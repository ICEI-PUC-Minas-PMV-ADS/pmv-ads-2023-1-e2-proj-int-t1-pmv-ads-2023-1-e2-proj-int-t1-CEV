/* eslint-disable react/no-array-index-key */

'use client';

import { IEntry, IProduct } from '@/types';
import {
  Button,
  Flex,
  FormControl,
  FormLabel,
  Grid,
  Input,
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
  submit: (id: string, qtd: number) => Promise<boolean>,
  products: IProduct[]
}

const CreateProductEntriesModal: React.FC<Props> = function ({
  isOpen,
  onClose,
  submit,
  products,
}) {
  const [entries, setEntries] = useState<IEntry[]>([]);
  const [selectedProduct, setSelectedProduct] = useState<IProduct>();
  const [selectedQtd, setSelectedQtd] = useState('');

  const remove = (index: number): void => {
    setEntries((old) => old.filter((sale, i) => i !== index));
  };

  const add = (): void => {
    if (!selectedProduct) return;

    setEntries((old) => [...old, {
      id: selectedProduct.id as string,
      name: selectedProduct.descricao,
      qtd: selectedQtd,
    }]);
    setSelectedQtd('');
  };

  useEffect(() => {
    setSelectedProduct(undefined);
    setEntries([]);
  }, [isOpen]);

  const [submiting, setSubmiting] = useState(false);
  const handleSubmit = async (): Promise<void> => {
    if (!selectedProduct) return;

    setSubmiting(true);

    const promises = entries.map(
      (entry) => submit(entry.id, parseInt(entry.qtd, 10)),
    );

    await Promise.all(promises);

    setSelectedProduct(undefined);
    setEntries([]);
    setSelectedQtd('');

    onClose();
    setSubmiting(false);
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <ModalOverlay />
      <ModalContent maxW="700px">
        <form>
          <ModalHeader>
            Novas Entradas
          </ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <Grid
              templateColumns={{ base: '1fr', lg: '3fr 1fr' }}
              gap="24px"
              mb="24px"
            >
              <FormControl>
                <FormLabel>Produto</FormLabel>
                <Select
                  value={selectedProduct?.id}
                  onChange={
                    (e) => setSelectedProduct(
                      products.find(
                        (p) => p.id.toString() === e.target.value.toString(),
                      ),
                    )

                  }
                >
                  <option>Selecione</option>
                  {
                    products.map((product) => (
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

              <FormControl>
                <FormLabel>Quantidade</FormLabel>
                <Input
                  value={selectedQtd}
                  onChange={(e) => setSelectedQtd(e.target.value)}
                  type="number"
                />
              </FormControl>
            </Grid>

            <Flex justifyContent="flex-end" mb="32px">
              <Button
                colorScheme="blue"
                onClick={add}
                isDisabled={!selectedProduct || !selectedQtd}
              >
                Adicionar
              </Button>
            </Flex>

            <Table mb="32px">
              <Thead>
                <Th>Produto</Th>
                <Th>Quantidade</Th>
                <Th>Ações</Th>
              </Thead>
              <Tbody>
                {
                  entries.map((entry, index) => (
                    <Tr key={index}>
                      <Td>{entry.name}</Td>
                      <Td>
                        {entry.qtd}
                      </Td>
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
              Cadastrar Entradas
            </Button>
          </ModalFooter>
        </form>
      </ModalContent>
    </Modal>
  );
};

export default CreateProductEntriesModal;
