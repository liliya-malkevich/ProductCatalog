import { Component } from '@angular/core';
import { IProduct } from '../../models/product';
import { ProductService } from '../../shared/services/product.service';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
  standalone: true,
  imports: [DxDataGridModule],
  providers: [ProductService],
})
export class ProductComponent {
  products: IProduct[] = [];
  constructor(private _productService: ProductService) {}

  ngOnInit(): void {
    this._productService.getProducts().subscribe((data) => {
      this.products = data;
    });
  }
}
