package com.travelplanner.utils

import androidx.fragment.app.Fragment
import com.travelplanner.TravelPlannerApplication
import com.travelplanner.di.IDIContainer

fun Fragment.di(): IDIContainer {
    return (this.requireActivity().application as TravelPlannerApplication).diContainer
}