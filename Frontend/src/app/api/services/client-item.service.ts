/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { ItemRequestDto } from '../models/item-request-dto';
import { ItemResponseDto } from '../models/item-response-dto';
import { ItemResponseForClientDto } from '../models/item-response-for-client-dto';

@Injectable({
  providedIn: 'root',
})
export class ClientItemService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiClientItemMyItemsGet
   */
  static readonly ApiClientItemMyItemsGetPath = '/api/ClientItem/my-items';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsGet$Plain(params?: {
  }): Observable<Array<ItemResponseDto>> {

    return this.apiClientItemMyItemsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsGet$Json(params?: {
  }): Observable<Array<ItemResponseDto>> {

    return this.apiClientItemMyItemsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * Path part for operation apiClientItemMyItemsPageGet
   */
  static readonly ApiClientItemMyItemsPageGetPath = '/api/ClientItem/my-items/page';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemsPageGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsPageGet$Plain$Response(params?: {
    nr?: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemsPageGetPath, 'get');
    if (params) {
      rb.query('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemsPageGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsPageGet$Plain(params?: {
    nr?: number;
  }): Observable<Array<ItemResponseDto>> {

    return this.apiClientItemMyItemsPageGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemsPageGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsPageGet$Json$Response(params?: {
    nr?: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemsPageGetPath, 'get');
    if (params) {
      rb.query('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemsPageGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemsPageGet$Json(params?: {
    nr?: number;
  }): Observable<Array<ItemResponseDto>> {

    return this.apiClientItemMyItemsPageGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * Path part for operation apiClientItemMyItemaNumberGet
   */
  static readonly ApiClientItemMyItemaNumberGetPath = '/api/ClientItem/my-itema/number';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemaNumberGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemaNumberGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemaNumberGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemaNumberGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemaNumberGet$Plain(params?: {
  }): Observable<number> {

    return this.apiClientItemMyItemaNumberGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemMyItemaNumberGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemaNumberGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemMyItemaNumberGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemMyItemaNumberGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemMyItemaNumberGet$Json(params?: {
  }): Observable<number> {

    return this.apiClientItemMyItemaNumberGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation apiClientItemItemStateGet
   */
  static readonly ApiClientItemItemStateGetPath = '/api/ClientItem/item-state';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemItemStateGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemItemStateGet$Plain$Response(params?: {
    itemId?: number;
  }): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemItemStateGetPath, 'get');
    if (params) {
      rb.query('itemId', params.itemId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemItemStateGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemItemStateGet$Plain(params?: {
    itemId?: number;
  }): Observable<string> {

    return this.apiClientItemItemStateGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemItemStateGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemItemStateGet$Json$Response(params?: {
    itemId?: number;
  }): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemItemStateGetPath, 'get');
    if (params) {
      rb.query('itemId', params.itemId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemItemStateGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemItemStateGet$Json(params?: {
    itemId?: number;
  }): Observable<string> {

    return this.apiClientItemItemStateGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * Path part for operation apiClientItemGetAllGet
   */
  static readonly ApiClientItemGetAllGetPath = '/api/ClientItem/get-all';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetAllGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetAllGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ItemResponseForClientDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetAllGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForClientDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetAllGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetAllGet$Plain(params?: {
  }): Observable<Array<ItemResponseForClientDto>> {

    return this.apiClientItemGetAllGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForClientDto>>) => r.body as Array<ItemResponseForClientDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetAllGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetAllGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ItemResponseForClientDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetAllGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForClientDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetAllGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetAllGet$Json(params?: {
  }): Observable<Array<ItemResponseForClientDto>> {

    return this.apiClientItemGetAllGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForClientDto>>) => r.body as Array<ItemResponseForClientDto>)
    );
  }

  /**
   * Path part for operation apiClientItemGetItemByPageNrGet
   */
  static readonly ApiClientItemGetItemByPageNrGetPath = '/api/ClientItem/get-item-by-page/{nr}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetItemByPageNrGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByPageNrGet$Plain$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseForClientDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetItemByPageNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForClientDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetItemByPageNrGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByPageNrGet$Plain(params: {
    nr: number;
  }): Observable<Array<ItemResponseForClientDto>> {

    return this.apiClientItemGetItemByPageNrGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForClientDto>>) => r.body as Array<ItemResponseForClientDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetItemByPageNrGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByPageNrGet$Json$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseForClientDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetItemByPageNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForClientDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetItemByPageNrGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByPageNrGet$Json(params: {
    nr: number;
  }): Observable<Array<ItemResponseForClientDto>> {

    return this.apiClientItemGetItemByPageNrGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForClientDto>>) => r.body as Array<ItemResponseForClientDto>)
    );
  }

  /**
   * Path part for operation apiClientItemNumberOfItemsGet
   */
  static readonly ApiClientItemNumberOfItemsGetPath = '/api/ClientItem/number-of-items';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemNumberOfItemsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemNumberOfItemsGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemNumberOfItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemNumberOfItemsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemNumberOfItemsGet$Plain(params?: {
  }): Observable<number> {

    return this.apiClientItemNumberOfItemsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemNumberOfItemsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemNumberOfItemsGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemNumberOfItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemNumberOfItemsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemNumberOfItemsGet$Json(params?: {
  }): Observable<number> {

    return this.apiClientItemNumberOfItemsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation apiClientItemGetItemByIdIdGet
   */
  static readonly ApiClientItemGetItemByIdIdGetPath = '/api/ClientItem/get-item-by-id/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetItemByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ItemResponseForClientDto>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetItemByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemResponseForClientDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetItemByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByIdIdGet$Plain(params: {
    id: number;
  }): Observable<ItemResponseForClientDto> {

    return this.apiClientItemGetItemByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ItemResponseForClientDto>) => r.body as ItemResponseForClientDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemGetItemByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ItemResponseForClientDto>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemGetItemByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemResponseForClientDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemGetItemByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemGetItemByIdIdGet$Json(params: {
    id: number;
  }): Observable<ItemResponseForClientDto> {

    return this.apiClientItemGetItemByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ItemResponseForClientDto>) => r.body as ItemResponseForClientDto)
    );
  }

  /**
   * Path part for operation apiClientItemAddItemPost
   */
  static readonly ApiClientItemAddItemPostPath = '/api/ClientItem/add-item';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemAddItemPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiClientItemAddItemPost$Plain$Response(params?: {
    body?: ItemRequestDto
  }): Observable<StrictHttpResponse<ItemRequestDto>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemAddItemPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemRequestDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemAddItemPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiClientItemAddItemPost$Plain(params?: {
    body?: ItemRequestDto
  }): Observable<ItemRequestDto> {

    return this.apiClientItemAddItemPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ItemRequestDto>) => r.body as ItemRequestDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemAddItemPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiClientItemAddItemPost$Json$Response(params?: {
    body?: ItemRequestDto
  }): Observable<StrictHttpResponse<ItemRequestDto>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemAddItemPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemRequestDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemAddItemPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiClientItemAddItemPost$Json(params?: {
    body?: ItemRequestDto
  }): Observable<ItemRequestDto> {

    return this.apiClientItemAddItemPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ItemRequestDto>) => r.body as ItemRequestDto)
    );
  }

  /**
   * Path part for operation apiClientItemIdDelete
   */
  static readonly ApiClientItemIdDeletePath = '/api/ClientItem/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiClientItemIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ClientItemService.ApiClientItemIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiClientItemIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiClientItemIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiClientItemIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
