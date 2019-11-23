import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { ShortProductService } from 'src/api/services';
import { ShortProductViewModel } from 'src/api/models';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductsComponent implements OnInit {
  products: ShortProductViewModel[];

  constructor(private shortProductService: ShortProductService, private activatedRoute: ActivatedRoute, private cdr: ChangeDetectorRef) { }
  ngOnInit() {
    this.activatedRoute.params.subscribe(result => {
      const categoryId = + result.id;
      this.load(categoryId);
    });
  }

  load(categoryId?: number) {
    this.shortProductService.GetByCategory(categoryId ? categoryId : null)
      .subscribe(result => {
        this.products = result;
        this.refresh();
      });
  }

  refresh() {
    this.cdr.detectChanges();
  }

  get IsAvailable(): boolean {
    if (this.products) {
      return this.products.length > 0;
    }
  }

}
