export interface IProduct {
  descricao: string,
  valor: number,
  id: string | number,
  estoque: number,
  // category: string
}

export interface ISale {
  product: IProduct,
  user: IUser,
}

export interface ISaleChart {
  dataVenda: string,
  somaProdutos: number
}

export interface ISaleItem {
  id: number,
  dataVenda: string,
  formaPagamento: number,
  vendedor: {
    id: number,
    nome: string
  },
  produtos: [
    {
      produtoId: number,
      produtoValor: number,
      quantidade: number
    }
  ]
}

export interface IUser {
  id: number,
  nome: string
}

export interface IUserForm {
  nome: string
}

export interface IEntry {
  id: string,
  name: string,
  qtd: string,
}

export interface IUseFetch {
  data: any,
  mutate: (data?: any, options?: any) => Promise<void>,
  error: any,
  isValidating: boolean,
}

export interface IProductForm {
  descricao: string,
  valor: number,
  estoque?: number
}
