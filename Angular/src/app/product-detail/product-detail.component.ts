import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { ProductService, OrderService } from 'src/api/services';
import { ActivatedRoute } from '@angular/router';
import { ProductViewModel, OrderViewModel } from 'src/api/models';
import { getCurrencySymbol } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
    styleUrls: ['./product-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductDetailComponent implements OnInit {
  product: ProductViewModel;
  constructor(private productService: ProductService, private orderService: OrderService,
              private activatedRoute: ActivatedRoute, private cdr: ChangeDetectorRef) { }

  model: OrderViewModel = {
    productCount: 1,
  };

  submitted = false;

  onSubmit() {
    const model = {
      productId: this.product.id,
      productCount: this.model.productCount,
      totalPrice: this.model.productCount * this.product.price,
    };
    this.orderService.Add(model
    ).subscribe(result => {
      if (result > 0) {
        this.model = model;
        this.model.id = result;
        this.submitted = true;
        this.cdr.detectChanges();
      }
    }
    );
  }

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

        this.model.productCount = 1;
        this.model.productId = this.product.id;
        this.model.totalPrice = this.product.price;
        this.refresh();
      });
  }

  refresh() {
    this.cdr.detectChanges();
  }
}
