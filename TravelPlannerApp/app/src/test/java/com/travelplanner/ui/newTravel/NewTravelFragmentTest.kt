package com.travelplanner.ui.newTravel

import android.os.Build
import androidx.fragment.app.testing.FragmentScenario
import androidx.fragment.app.testing.launchFragmentInContainer
import androidx.lifecycle.MutableLiveData
import androidx.test.espresso.Espresso.onView
import androidx.test.espresso.action.ViewActions.click
import androidx.test.espresso.action.ViewActions.replaceText
import androidx.test.espresso.assertion.ViewAssertions.matches
import androidx.test.espresso.matcher.RootMatchers.isDialog
import androidx.test.espresso.matcher.ViewMatchers.*
import androidx.test.ext.junit.runners.AndroidJUnit4
import com.marcellogalhardo.fixture.Fixture
import com.marcellogalhardo.fixture.nextListOf
import com.nhaarman.mockitokotlin2.*
import com.travelplanner.R
import com.travelplanner.models.Location
import com.travelplanner.models.Travel
import org.junit.Before
import org.junit.Test
import org.junit.runner.RunWith
import org.robolectric.annotation.Config

@RunWith(AndroidJUnit4::class)
class NewTravelFragmentTest {

    val fixture = Fixture {}
    private val toastMock: MutableLiveData<String> = spy()
    private val travelMock: MutableLiveData<Travel> = spy()
    private val locationMock: MutableLiveData<String> = spy()
    private val locationsMock: MutableLiveData<List<Location>> = spy()

    private val viewModel: NewTravelViewModel = mock<NewTravelViewModel> {
        on { toastError } doReturn(toastMock)
        on { travel } doReturn travelMock
        on { location } doReturn locationMock
        on { locations } doReturn locationsMock
    }


    private lateinit var fragment: FragmentScenario<NewTravelFragment>

    @Before
    fun setup() {
        val f = NewTravelFragment()
        f.setViewModel(viewModel)
        fragment = launchFragmentInContainer(themeResId = R.style.Theme_TravelPlanner) { f }

    }

    @Test
    @Config(sdk = [Build.VERSION_CODES.P])
    fun shouldSearchLocations_andDisplayResultsInDialog() {
        val locations = fixture.nextListOf<Location>(4)
        onView(withId(R.id.new_travel_location)).perform(replaceText("Test location"))
        whenever(viewModel.getLocations(any())).then {
            locationsMock.postValue(locations)
        }

        onView(withId(R.id.new_travel_location_search_button)).perform(click())
        verify(viewModel).getLocations(eq("Test location"))

        for (loc in locations) {
            onView(withText("${loc.name}, ${loc.countryId}"))
                .inRoot(isDialog())
                .check(matches(isDisplayed()))
        }
    }

    @Test
    @Config(sdk = [Build.VERSION_CODES.P])
    fun shouldSetChosenLocation() {
        val locations = fixture.nextListOf<Location>(3)
        locationsMock.postValue(locations)
        val expectedDisplayName = "${locations[1].name}, ${locations[1].countryId}"
        onView(withText(expectedDisplayName))
            .inRoot(isDialog())
            .perform(click())

        onView(withId(R.id.new_travel_location))
            .check(matches(withText(expectedDisplayName)))
    }
}