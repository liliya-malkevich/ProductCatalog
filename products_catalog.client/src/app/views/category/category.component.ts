import { Component, OnInit } from '@angular/core';
import {
  DxButtonModule,
  DxDataGridComponent,
  DxDataGridModule,
} from 'devextreme-angular';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../models/category';
import { ToolbarPreparingEvent } from 'devextreme/ui/data_grid';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
  standalone: true,
  imports: [DxDataGridModule, DxButtonModule],
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

  public onToolbarPreparing(e: ToolbarPreparingEvent): void {
    e.toolbarOptions.items?.unshift({
      location: 'before',
      template: 'actionBtnGroup',
      locateInMenu: 'auto',
    });
  }

  public createCategory() {}
}
