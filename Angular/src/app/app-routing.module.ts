import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


const appRoutes: Routes = [
  { path: 'product/:id',      component: ProductDetailComponent },
  {
    path: 'category/:id',
    component: ProductsComponent,
  },
  {
    path: 'category',
    component: ProductsComponent,
  },
  {
    path: '',
    redirectTo: '/category',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
