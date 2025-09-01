import {ProductService, Product}  from  ''
import {Carts}  from  'cart'

@Component({
    selector: "app-product-list",
    templateUrl: "./product-list.component.html",
    styleUrls: ["./product-list.component.css"]
});

export class ProductListComponent implements OnInit {
    products: Product[] = [];

    constructor(private productService: ProductService, private cartService: CartItemService) {}

    ngOnInit(): void {
        this.loadProducts();
    }

    loadProducts(): void {
        this.productService.getProducts().subscribe((data) => {
            this.products = data;
        });
    }

    addToCart(product: Product): void {
        this.cartService.addToCart(product.id, 1).subscribe(() => {
            console.log("Product added to cart");
        });
    }
}