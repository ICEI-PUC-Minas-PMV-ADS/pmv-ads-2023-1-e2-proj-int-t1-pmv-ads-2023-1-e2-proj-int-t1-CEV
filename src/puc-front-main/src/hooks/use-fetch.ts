import axios from 'axios';
import useSWR from 'swr';

export interface IUseFetch {
  data: any,
  mutate: (data?: any, options?: any) => Promise<void>,
  error: any,
  isValidating: boolean,
}

export const api = axios.create(
  { baseURL: 'https://cev-api.azurewebsites.net' },
);

const useFetch = (
  url: string | null,
  disableRevalidation?: boolean,
): IUseFetch => {
  // const handleErrors = useHandleErrors();

  const options = disableRevalidation ? {
    revalidateIfStale: false,
    revalidateOnFocus: false,
    revalidateOnReconnect: false,
  } : {};

  const {
    data, mutate, error, isValidating,
  } = useSWR(url, async (u: string) => {
    const response = await api.get(u);

    return response.data;
  }, options);

  if (error) {
    // handleErrors(error.response.data);
  }

  return {
    data, mutate, error, isValidating,
  };
};

export default useFetch;
