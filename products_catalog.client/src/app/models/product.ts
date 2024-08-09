import { ICategory } from './category';

export interface IProduct {
  id: number;
  name?: string;
  categoryItemId: number;
  categoryItem?: ICategory;
  description?: string;
  price?: string;
  note?: string;
  noteSpec?: string;
}
