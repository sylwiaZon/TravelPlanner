package com.travelplanner

import android.view.Gravity
import androidx.test.core.app.launchActivity
import androidx.test.espresso.Espresso.onView
import androidx.test.espresso.assertion.ViewAssertions.matches
import androidx.test.espresso.contrib.DrawerActions
import androidx.test.espresso.contrib.DrawerMatchers.isClosed
import androidx.test.espresso.contrib.NavigationViewActions
import androidx.test.espresso.matcher.ViewMatchers.*
import androidx.test.filters.MediumTest
import com.nhaarman.mockitokotlin2.mock
import com.nhaarman.mockitokotlin2.whenever
import com.travelplanner.models.Travel
import com.travelplanner.models.TravelDestination
import com.travelplanner.models.TravelParticipants
import io.reactivex.Single

import org.junit.Test
import java.time.LocalDateTime

@MediumTest
class MainActivityTest {

    @Test
    fun shouldChangeViewToAllTravels_AndDisplayData() {
        val travels = listOf(
            Travel("id1", LocalDateTime.now(), LocalDateTime.now(), TravelParticipants(0, emptyList(), 2), TravelDestination("KRAKOW", "POLSKA"), "")
        )
        TravelPlannerRunner.di.travelApiService = mock()
        whenever(TravelPlannerRunner.di.travelApiService.getTravels())
            .thenReturn(Single.just(travels))

        val scenario = launchActivity<MainActivity>()


        onView(withId(R.id.drawer_layout))
            .check(matches(isClosed(Gravity.LEFT))) // Left Drawer should be closed.
            .perform(DrawerActions.open()); // Open Drawer

        onView(withId(R.id.nav_view))
            .perform(NavigationViewActions.navigateTo(R.id.nav_all_travels))

        onView(withText(travels[0].travelDestination.city)).check(matches(isDisplayed()))
    }
}