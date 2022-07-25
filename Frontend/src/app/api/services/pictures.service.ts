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

import { PictureRequestDto } from '../models/picture-request-dto';
import { PictureResponseDto } from '../models/picture-response-dto';

@Injectable({
  providedIn: 'root',
})
export class PicturesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiPicturesIdGet
   */
  static readonly ApiPicturesIdGetPath = '/api/Pictures/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<PictureResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PictureResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesIdGet$Plain(params: {
    id: number;
  }): Observable<PictureResponseDto> {

    return this.apiPicturesIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<PictureResponseDto>) => r.body as PictureResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<PictureResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PictureResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesIdGet$Json(params: {
    id: number;
  }): Observable<PictureResponseDto> {

    return this.apiPicturesIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<PictureResponseDto>) => r.body as PictureResponseDto)
    );
  }

  /**
   * Path part for operation apiPicturesShowIdGet
   */
  static readonly ApiPicturesShowIdGetPath = '/api/Pictures/show/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesShowIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesShowIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesShowIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'blob',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Blob>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesShowIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesShowIdGet$Plain(params: {
    id: number;
  }): Observable<Blob> {

    return this.apiPicturesShowIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesShowIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesShowIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesShowIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'blob',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Blob>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesShowIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPicturesShowIdGet$Json(params: {
    id: number;
  }): Observable<Blob> {

    return this.apiPicturesShowIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation apiPicturesPost
   */
  static readonly ApiPicturesPostPath = '/api/Pictures';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesPost$Plain()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesPost$Plain$Response(params?: {
    body?: {
'Image'?: Blob;
'Description'?: string;
}
  }): Observable<StrictHttpResponse<PictureResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesPostPath, 'post');
    if (params) {
      rb.body(params.body, 'multipart/form-data');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PictureResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesPost$Plain$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesPost$Plain(params?: {
    body?: {
'Image'?: Blob;
'Description'?: string;
}
  }): Observable<PictureResponseDto> {

    return this.apiPicturesPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<PictureResponseDto>) => r.body as PictureResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesPost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesPost$Json$Response(params?: {
    body?: {
'Image'?: Blob;
'Description'?: string;
}
  }): Observable<StrictHttpResponse<PictureResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesPostPath, 'post');
    if (params) {
      rb.body(params.body, 'multipart/form-data');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PictureResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesPost$Json$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesPost$Json(params?: {
    body?: {
'Image'?: Blob;
'Description'?: string;
}
  }): Observable<PictureResponseDto> {

    return this.apiPicturesPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<PictureResponseDto>) => r.body as PictureResponseDto)
    );
  }

  /**
   * Path part for operation apiPicturesListPost
   */
  static readonly ApiPicturesListPostPath = '/api/Pictures/list';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesListPost$Plain()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesListPost$Plain$Response(params?: {
    body?: {
'pics'?: Array<PictureRequestDto>;
}
  }): Observable<StrictHttpResponse<Array<PictureResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesListPostPath, 'post');
    if (params) {
      rb.body(params.body, 'multipart/form-data');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<PictureResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesListPost$Plain$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesListPost$Plain(params?: {
    body?: {
'pics'?: Array<PictureRequestDto>;
}
  }): Observable<Array<PictureResponseDto>> {

    return this.apiPicturesListPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<PictureResponseDto>>) => r.body as Array<PictureResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPicturesListPost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesListPost$Json$Response(params?: {
    body?: {
'pics'?: Array<PictureRequestDto>;
}
  }): Observable<StrictHttpResponse<Array<PictureResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, PicturesService.ApiPicturesListPostPath, 'post');
    if (params) {
      rb.body(params.body, 'multipart/form-data');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<PictureResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPicturesListPost$Json$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiPicturesListPost$Json(params?: {
    body?: {
'pics'?: Array<PictureRequestDto>;
}
  }): Observable<Array<PictureResponseDto>> {

    return this.apiPicturesListPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<PictureResponseDto>>) => r.body as Array<PictureResponseDto>)
    );
  }

}
