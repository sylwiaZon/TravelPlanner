package com.travelplanner

import android.app.Application
import com.travelplanner.di.DIContainer
import com.travelplanner.di.IDIContainer

class TravelPlannerApplication : Application() {
    var diContainer: IDIContainer = DIContainer
}