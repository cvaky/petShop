import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { ProductService } from 'src/api/services';
import { ActivatedRoute } from '@angular/router';
import { ProductViewModel, OrderViewModel } from 'src/api/models';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductDetailComponent implements OnInit {
  product: ProductViewModel;
  constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private cdr: ChangeDetectorRef) { }

  model: OrderViewModel = {
    productCount : 1,
    productId : 1,
    totalPrice: 0
  };

  submitted = false;

  onSubmit() { this.submitted = true; }

  ngOnInit() {
    this.activatedRoute.params.subscribe(result => {
      const productId = + result.id;
      this.load(productId);
    });
  }

  load(productId?: number) {
    this.productService.Get(productId ? productId : null)
      .subscribe(result => {
        this.product = result;

        this.model = {
          productCount: 1,
          productId: this.product.id
        };

        this.refresh();
      });
  }

  refresh() {
    this.cdr.detectChanges();
  }
}
