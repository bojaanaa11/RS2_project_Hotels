import { Injectable } from '@angular/core';
import { LocalStorageKeys } from './local-storage-keys';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  public set(key: LocalStorageKeys, value: any): void {
    console.log("set key for "+key+" to local storage")
    localStorage.setItem(key, JSON.stringify(value));
  }

  public get(key: LocalStorageKeys): any | null {
    console.log("get key for "+key.length+" to local storage")
    const value: string | null = localStorage.getItem(key);
    console.log(value);
    if(value === null) {
      return null;
    }

    return JSON.parse(value);
  }

  public clear(key: LocalStorageKeys): void {
    localStorage.removeItem(key);
  }
}
