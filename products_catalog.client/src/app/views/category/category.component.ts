import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular';
import { CategoryService } from '../../shared/services/category.service';
import { ICategory } from '../../models/category';
import {
  RowInsertingEvent,
  RowRemovingEvent,
  RowUpdatingEvent,
} from 'devextreme/ui/data_grid';
import { Subscription, switchMap } from 'rxjs';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
  standalone: true,
  imports: [DxDataGridModule],
  providers: [CategoryService],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoryComponent implements OnInit, OnDestroy {
  categories: ICategory[] = [];
  subscription = new Subscription();
  constructor(
    private _catService: CategoryService,
    private _cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.subscription.add(
      this._catService.getCategories().subscribe((data) => {
        this.categories = data;
        this._cdr.markForCheck();
      })
    );
  }

  public addCategory(e: RowInsertingEvent) {
    this.subscription.add(
      this._catService
        .addCategory({ id: 0, name: e.data.name })
        .pipe(switchMap(() => this._catService.getCategories()))
        .subscribe((data) => {
          this.categories = data;
          this._cdr.markForCheck();
        })
    );
  }

  public deleteCategory(e: RowRemovingEvent) {
    this.subscription.add(
      this._catService.deleteCategory(e.data.id).subscribe()
    );
  }

  public updateCategory(e: RowUpdatingEvent) {
    this.subscription.add(
      this._catService
        .updateCategory({ id: e.key, name: e.newData.name })
        .subscribe()
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
