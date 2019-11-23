/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { ProductViewModel } from '../models/product-view-model';
@Injectable({
  providedIn: 'root',
})
class ProductService extends __BaseService {
  static readonly GetPath = '/api/Product/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   * @return Success
   */
  GetResponse(id: number): __Observable<__StrictHttpResponse<ProductViewModel>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Product/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ProductViewModel>;
      })
    );
  }
  /**
   * @param id undefined
   * @return Success
   */
  Get(id: number): __Observable<ProductViewModel> {
    return this.GetResponse(id).pipe(
      __map(_r => _r.body as ProductViewModel)
    );
  }
}

module ProductService {
}

export { ProductService }
