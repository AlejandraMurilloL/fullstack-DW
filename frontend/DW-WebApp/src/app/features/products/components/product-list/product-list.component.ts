import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { confirm } from 'devextreme/ui/dialog';
import notify from 'devextreme/ui/notify';
import { ProductList } from '../../models/product-list';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products: ProductList[] = [];

  constructor(private productsService: ProductsService,
              private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.loadDatos();
  }
  
  loadDatos() {
    this.productsService.getProducts().subscribe((datos) => {
      this.products = datos;
    });
  }

  onToolbarPreparing(e: any): void {
    e.toolbarOptions.items.unshift({
      location: 'after',
      widget: 'dxButton',
      options: {
        icon: 'add',
        hint: 'Nuevo',
        type: 'success',
        onClick: this.onNewClick.bind(this),
      },
    });
  }

  onNewClick(): void {
    this.router.navigate(['/productos/nuevo']);
  }

  onEditClick(item: any): void {
    this.router.navigate(['/productos/editar', item.id]);
  }

  onRemoveClick(data: any): void {
    let result = confirm("<i>¿Está seguro de que desea eliminar el Producto seleccionado?</i>", "Advertencia");
    result.then((dialogResult) => {
        if (dialogResult) {
          this.productsService.deleteProduct(data.id).subscribe({
            next: this.loadDatos.bind(this),
            error: ({error}) => { this.showAlertError(error) }           
          });
        }
    });
  }

  private showAlertError(error: string): void {
    notify({
      message: error,
      position: {
        my: 'center top',
        at: 'center top',
      },
    }, 'error', 4000);
  }

}
