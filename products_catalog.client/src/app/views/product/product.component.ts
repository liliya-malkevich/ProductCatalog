import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { IProduct } from '../../models/product';
import { ProductService } from '../../shared/services/product.service';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import { Subscription, switchMap } from 'rxjs';
import {
  RowInsertingEvent,
  RowRemovingEvent,
  RowUpdatingEvent,
} from 'devextreme/ui/data_grid';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../models/category';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
  standalone: true,
  imports: [DxDataGridModule],
  providers: [ProductService, CategoryService],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductComponent implements OnInit, OnDestroy {
  products: IProduct[] = [];
  categories: ICategory[] = [];
  subscription = new Subscription();
  constructor(
    private _productService: ProductService,
    private _catService: CategoryService,
    private _cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.subscription.add(
      this._productService.getProducts().subscribe((data) => {
        this.products = data;
        this._cdr.markForCheck();
      })
    );
    this.subscription.add(
      this._catService.getCategories().subscribe((data) => {
        this.categories = data;
        this._cdr.markForCheck();
      })
    );
  }

  public addProduct(e: RowInsertingEvent) {
    this.subscription.add(
      this._productService
        .addProduct(e.data)
        .pipe(switchMap(() => this._productService.getProducts()))
        .subscribe((data) => {
          this.products = data;
          this._cdr.markForCheck();
        })
    );
  }

  public deleteProduct(e: RowRemovingEvent) {
    this.subscription.add(
      this._productService.deleteProduct(e.data.id).subscribe()
    );
  }

  public updateProduct(e: RowUpdatingEvent) {
    console.log(e);
    this.subscription.add(
      this._productService
        .updateProduct({
          id: e.key,
          name: !!e.newData.name ? e.newData.name : e.oldData.name,
          categoryItemId: !!e.newData.categoryItemId
            ? e.newData.categoryItemId
            : e.oldData.categoryItemId,
          description: !!e.newData.description
            ? e.newData.description
            : e.oldData.description,
          price: !!e.newData.price ? e.newData.price : e.oldData.price,
          note: !!e.newData.note ? e.newData.note : e.oldData.note,
          noteSpec: !!e.newData.noteSpec
            ? e.newData.noteSpec
            : e.oldData.noteSpec,
        })
        .subscribe()
    );
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
