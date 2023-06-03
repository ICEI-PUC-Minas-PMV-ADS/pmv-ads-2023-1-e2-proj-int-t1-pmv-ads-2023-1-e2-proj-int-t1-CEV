import useFetch, { api } from '@/hooks/use-fetch';
import {
  IUser, IUserForm, IUseFetch,
} from '@/types';
import { useToast } from '@chakra-ui/react';
import useUser from './use-user';

interface IUseUsers {
  users: IUser[] | undefined,
  createUser: (form: IUserForm) => Promise<boolean>,
  removeUser: (id: string) => Promise<boolean>,
  updateUser: (id: string, form: IUserForm) => Promise<boolean>,
}

interface IFetch extends IUseFetch {
  data: IUser[] | undefined,
}

const useUsers = (): IUseUsers => {
  const { data: users, mutate }: IFetch = useFetch('/vendedor');
  const toast = useToast();

  const { updateUser: onUpdate } = useUser();

  const createUser = async (form: IUserForm): Promise<boolean> => {
    try {
      await api.post('/vendedor', form);
      await mutate();
      toast({
        status: 'success',
        title: 'Vendedor criado com sucesso',
      });
      return true;
    } catch (error) {
      toast({
        status: 'error',
        title: 'Algo de errado aconteceu',
      });
      return false;
    }
  };

  const removeUser = async (id: string): Promise<boolean> => {
    try {
      await api.delete(`/vendedor/${id}`);
      await mutate();
      toast({
        status: 'success',
        title: 'Vendedor removido com sucesso',
      });
      return true;
    } catch (error) {
      toast({
        status: 'error',
        title: 'Algo de errado aconteceu',
      });
      return false;
    }
  };

  const updateUser = async (
    id: string,
    form: IUserForm,
  ): Promise<boolean> => {
    const success = await onUpdate(form, id);
    if (success) {
      await mutate();
    }

    return success;
  };

  return {
    users,
    createUser,
    removeUser,
    updateUser,
  };
};

export default useUsers;
