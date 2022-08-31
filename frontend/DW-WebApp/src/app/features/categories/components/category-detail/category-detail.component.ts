import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { CategoryDetail } from '../../models/category-detail';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit {

  category: CategoryDetail;

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private categoriesService: CategoriesService) 
  {
    this.category = new CategoryDetail();
  }

  ngOnInit(): void {
    if (!this.router.url.includes('editar')) {
      return;
    }

    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.categoriesService.getCategory(id))
      )
      .subscribe(category => this.category = category);
  }

  onSaveClick(): void {
    this.categoriesService.saveCategory(this.category).subscribe(() => {
      this.router.navigate(['/categorias/listado']);
    });
  }

  onBackClick(): void {
    this.router.navigate(['/categorias/listado']);
  }
}
