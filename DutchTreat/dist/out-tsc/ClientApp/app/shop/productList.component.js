import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ProductList = class ProductList {
    constructor(data) {
        this.data = data;
        this.products = [];
    }
    ngOnInit() {
        this.data.loadProducts().subscribe(success => { this.products = this.data.products; });
    }
};
ProductList = __decorate([
    Component({
        selector: 'product-list',
        templateUrl: 'productList.component.html',
        styleUrls: []
    })
], ProductList);
export { ProductList };
//# sourceMappingURL=productList.component.js.map