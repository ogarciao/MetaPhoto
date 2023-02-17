import { NgModule } from "@angular/core";

import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
    imports: [MatPaginatorModule, MatInputModule, MatIconModule, MatButtonModule, MatTooltipModule,
        MatProgressSpinnerModule, MatDialogModule, MatToolbarModule],
    exports: [MatPaginatorModule, MatInputModule, MatIconModule, MatButtonModule, MatTooltipModule,
        MatProgressSpinnerModule, MatDialogModule, MatToolbarModule]
})

export class AngularMaterialModules { }