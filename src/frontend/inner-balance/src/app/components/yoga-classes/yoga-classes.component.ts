import { Component, Inject, OnInit } from '@angular/core';
import { YogaClass } from 'src/app/models/yoga-class';
import { YogaClassesService } from 'src/app/services/yoga-classes.service';

@Component({
  selector: 'ib-yoga-classes',
  templateUrl: './yoga-classes.component.html',
  styleUrls: ['./yoga-classes.component.scss']
})
export class YogaClassesComponent implements OnInit {
  public title: string = "Scheduled Yoga Classes";
  public yogaClasses: YogaClass[] = [];

  public showAddDialog: boolean = false;
  public showEditDialog: boolean = false;

  public selectedItem: YogaClass | undefined;

  constructor(
    @Inject(YogaClassesService) private readonly yogaClassesService: YogaClassesService,
    ) {
  }

  ngOnInit(): void {
    this.loadYogaClasses();
  }

  public loadYogaClasses(): void {
    this.yogaClassesService.getAll().subscribe(
      (result) => {
        this.yogaClasses = [...result];
      }
    )
  }

  public add(){
    console.log('add');
  }

  public edit(item: YogaClass){
    console.log('edit', item)
  }

  public delete(id: number){
    console.log('delete', id);
    this.yogaClassesService.delete(id).subscribe(
      (result) => {
        console.log(result);
        this.loadYogaClasses();
      }
    )
  }
}
