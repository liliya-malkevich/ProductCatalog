import { Component, OnInit } from '@angular/core';
import { DxDataGridComponent, DxDataGridModule } from 'devextreme-angular';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../models/category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
  standalone: true,
  imports: [DxDataGridModule],
  providers: [CategoryService],
})
export class CategoryComponent implements OnInit {
  categories: ICategory[] = [];
  constructor(private _catService: CategoryService) {}

  ngOnInit(): void {
    this._catService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }
}
