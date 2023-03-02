import { NgModule } from "@angular/core";
import { DxPieChartModule } from "devextreme-angular";
import { DxChartModule } from "devextreme-angular/ui/chart";
import { DxDataGridModule } from "devextreme-angular/ui/data-grid";


const DevExtremeComponents = [
    DxDataGridModule,
    DxChartModule,
    DxPieChartModule,
];

@NgModule({
    declarations: [],
    imports: [DevExtremeComponents],
    exports: [DevExtremeComponents]
})
export class AngularDevExtremeModule { }
