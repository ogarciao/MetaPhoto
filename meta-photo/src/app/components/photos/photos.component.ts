import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { finalize, map, merge, Observable, Subscription } from 'rxjs';
import { Photo } from 'src/app/dtos/photo';
import { PhotosService } from 'src/app/services/photos.service';
import { PhotoComponent } from '../photo/photo.component';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnDestroy {
  limit: number = 25;
  offset: number = 0;
  total: number = 0;
  photos: Photo[] = [];
  title: string | undefined;
  albumTitle: string | undefined;
  email: string | undefined;
  canClearFilters = false;

  subscription;
  loading = false;

  constructor(private photosService: PhotosService, private router: Router, private route: ActivatedRoute, public dialog: MatDialog) {
     this.subscription = route.queryParams.subscribe(params => {
      this.limit = params['limit'];
      this.offset = params['offset'];
      this.title = params['title']
      this.albumTitle = params['albumTitle'];
      this.email = params['email'];

      this.canClearFilters = params['title'] || params['albumTitle'] || params['email'];

      this.getPhotos();
    });
    
  }

  getPhotos() {
    this.loading = true;
    this.photosService.getPhotos(this.title, this.albumTitle, this.email, this.limit, this.offset)
      .pipe(finalize(() => this.loading = false))
      .subscribe(data => {          
        this.photos = data.body ?? [];
        this.total = +(data.headers.get('x-total-count') ?? 0);
      });
  }

  onPagination(event: PageEvent) {
    let queryParams = {
      limit: event.pageSize,
      offset: event.pageSize * event.pageIndex
    };

    this.router.navigate(
      [],
      {
        relativeTo: this.route,
        queryParams: queryParams,
        queryParamsHandling: 'merge'
      }
    );
  }

  onFilter()
  {
    let queryParams = {
      title: this.title && this.title.length > 0 ? this.title : null,
      albumTitle: this.albumTitle && this.albumTitle.length > 0 ? this.albumTitle : null,
      email: this.email && this.email.length > 0 ? this.email : null
    };

    this.router.navigate(
      [],
      {
        relativeTo: this.route,
        queryParams: queryParams,
        queryParamsHandling: 'merge'
      }
    );

    this.getPhotos();
  }

  onClearFilters() {
    this.title = undefined;
    this.albumTitle = undefined;
    this.email = undefined;

    this.onFilter();
  }

  onImageClick(photo: Photo) {
    this.dialog.open(PhotoComponent, {
      data: photo,
      width: "900px",
      height: "600px"
    })
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
