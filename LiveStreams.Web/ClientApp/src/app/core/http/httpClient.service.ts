import { Injectable} from '@angular/core';
import axios from "axios";
import { AxiosInstance } from "axios";
import { ErrorHandler } from "@angular/core";
import { 
    HttpClient
 } from '@angular/common/http';

 export interface Params {
  [ key: string ]: any;
}

export interface GetOptions {
  url: string;
  params?: Params;
}

export interface ErrorResponse {
  id: string;
  code: string;
  message: string;
}

@Injectable()
export class HttpClientService {
  private axiosClient: AxiosInstance;
  private errorHandler: ErrorHandler;
  private _apiUrl: string = "http://localhost:5050/api/";

  constructor( errorHandler: ErrorHandler ) {

      this.errorHandler = errorHandler;

      // The ApiClient wraps calls to the underlying Axios client.
      this.axiosClient = axios.create({
          timeout: 3000,
          headers: {
              "X-Initialized-At": Date.now().toString()
          }
      });

  }

  public async get<T>( options: GetOptions ) : Promise<T> {

      try {

          var axiosResponse = await this.axiosClient.request<T>({
              method: "get",
              url: this._apiUrl + options.url,
              params: options.params
          });

          return( axiosResponse.data );

      } catch ( error ) {

          return( Promise.reject( this.normalizeError( error ) ) );

      }

  }

  // Errors can occur for a variety of reasons. Normalize the error response so that
  // the calling context can assume a standard error structure.
  private normalizeError( error: any ) : ErrorResponse {

      this.errorHandler.handleError( error );

      // NOTE: Since I'm not really dealing with a production API, this doesn't really
      // normalize anything yet
      return({
          id: "-1",
          code: "UnknownError",
          message: "An unexpected error occurred."
      });

  }
}