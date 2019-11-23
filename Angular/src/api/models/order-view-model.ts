/* tslint:disable */
import { ProductViewModel } from './product-view-model';
export interface OrderViewModel {
  totalPrice?: number;
  productCount?: number;
  productId?: number;
  product?: ProductViewModel;
  timeStamp?: string;
  id?: number;
}
