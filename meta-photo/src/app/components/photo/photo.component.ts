import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Photo } from 'src/app/dtos/photo';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent {

  constructor(public dialogRef: MatDialogRef<PhotoComponent>, @Inject(MAT_DIALOG_DATA) public data: Photo) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
