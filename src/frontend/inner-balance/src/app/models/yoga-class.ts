import { Time } from "@angular/common";
import { DifficultyLevel } from "./difficulty-level";

export interface YogaClass {
    id: number,
    name: string,
    description?: string,
    room?: number,
    style?: number,
    difficultyLevel: DifficultyLevel,
    date: Date,
    startTime: Time,
    endTime: Time,
    numberOfSpots: number,
    teacherId: string,
    participants: string[],
}