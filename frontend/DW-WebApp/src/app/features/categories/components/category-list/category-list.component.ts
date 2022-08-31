import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { confirm } from 'devextreme/ui/dialog';
import { CategoryList } from '../../models/category-list';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  
  categories: CategoryList[] = [];

  constructor(private categoriesService: CategoriesService,
              private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.loadDatos();
  }
  
  loadDatos() {
    this.categoriesService.getCategories().subscribe((datos) => {
      this.categories = datos;
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
    this.router.navigate(['/categorias/nuevo']);
  }

  onEditClick(item: any): void {
    this.router.navigate(['/categorias/editar', item.id]);
  }

  onRemoveClick(data: any): void {
    let result = confirm("<i>¿Está seguro de que desea eliminar la categoria seleccionada?</i>", "Advertencia");
    result.then((dialogResult) => {
        if (dialogResult) {
          this.categoriesService.deleteCategory(data.id).subscribe(this.loadDatos.bind(this));
        }
    });
  }

}
