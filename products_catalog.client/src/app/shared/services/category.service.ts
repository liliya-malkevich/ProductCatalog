import { Inject, Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { HttpClient } from '@angular/common/http';
import { ICategory } from '../../models/category';
import { Observable } from 'rxjs';

@Injectable()
export class CategoryService extends HttpService {
  constructor(
    protected override http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    super(http);
  }

  public getCategories(): Observable<ICategory[]> {
    return this.sendRequest(this.baseUrl + `api/Category`);
  }

  public getCategory(id: number): Observable<ICategory> {
    return this.sendRequest(this.baseUrl + `api/Category/${id}`);
  }

  public addCategory(category: ICategory): Observable<ICategory> {
    return this.sendRequest(this.baseUrl + `api/Category`, 'POST', category);
  }

  public updateCategory(category: ICategory): Observable<ICategory> {
    return this.sendRequest(this.baseUrl + `api/Category`, 'PUT', category);
  }

  public deleteCategory(id: number): Observable<ICategory> {
    return this.sendRequest(this.baseUrl + `api/Category/${id}`, 'DELETE');
  }
}
