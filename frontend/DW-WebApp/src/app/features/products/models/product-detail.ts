import { Category } from './category';

export class ProductDetail {
    id?: number;
    name!: string;
    price!: number;
    stock!: number;
    category!: Category;
}