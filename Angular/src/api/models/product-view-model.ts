/* tslint:disable */
import { AnimalCategoryViewModel } from './animal-category-view-model';
export interface ProductViewModel {
  description?: string;
  animalCategoryId?: number;
  animalCategory?: AnimalCategoryViewModel;
  name?: string;
  price?: number;
  id?: number;
}
