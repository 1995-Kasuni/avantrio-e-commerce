import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CartItem {
    productId: number;
    productQuantity: number;
}

@Injectable({
    providedIn: 'root'
})

export class CartItemService {
    private apiUrl = 'https://localhost:3000/cart';

    constructor(private http: HttpClient) {}

    addToCart(productId: number, productQuantity: number): Observable<CartItem> {
        const item: CartItem = { productId, productQuantity : 1 };
        return this.http.post<CartItem>(this.apiUrl, item);
    }

    getCartItems(): Observable<CartItem[]> {
        return this.http.get<CartItem[]>(this.apiUrl);
    }

}
