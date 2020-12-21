package com.travelplanner.ui.newTravel

import androidx.arch.core.executor.testing.InstantTaskExecutorRule
import com.google.common.truth.Truth.assertThat
import com.marcellogalhardo.fixture.Fixture
import com.marcellogalhardo.fixture.nextListOf
import com.nhaarman.mockitokotlin2.*
import com.travelplanner.api.LocationInfoApiService
import com.travelplanner.api.TravelApiService
import com.travelplanner.models.Location
import com.travelplanner.utils.RxSchedulers
import io.reactivex.Single
import io.reactivex.schedulers.Schedulers
import org.junit.Rule
import org.junit.Test
import org.junit.rules.TestRule


class NewTravelViewModelTest {

    @get:Rule
    var rule: TestRule = InstantTaskExecutorRule()

    private val fixture = Fixture {  }

    private val travelApiService = mock<TravelApiService> {  }
    private val locationInfoApiService = mock<LocationInfoApiService> {  }
    private val schedulers = mock<RxSchedulers> {
        on { io() } doReturn Schedulers.trampoline()
        on { uiThread() } doReturn Schedulers.trampoline()
    }

    private val viewModel = NewTravelViewModel(travelApiService, locationInfoApiService, schedulers)


    @Test
    fun getLocations_shouldReturnLocations() {
        val city = "city1"
        val locations = fixture.nextListOf<Location>(3)
        whenever(locationInfoApiService.getLocation(any())).thenReturn(Single.just(locations))
        viewModel.locations.observeForever(mock())

        viewModel.getLocations(city)

        verify(locationInfoApiService).getLocation(eq(city))
        assertThat(viewModel.locations.value).isEqualTo(locations)
    }
}