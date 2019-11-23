import { Component, OnInit, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { AnimalCategoryService } from 'src/api/services';
import { AnimalCategoryViewModel } from 'src/api/models';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CategoriesComponent implements OnInit {
  categories: AnimalCategoryViewModel[];
  constructor(private animalCategoryService: AnimalCategoryService, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.animalCategoryService.GetAll()
    .subscribe(result => {
      this.categories = result;
      this.refresh();
    });
  }

  refresh() {
    this.cdr.detectChanges();
  }

}
