package com.travelplanner.ui.newTravel

import androidx.annotation.NonNull
import com.google.common.truth.Truth.assertThat
import com.marcellogalhardo.fixture.Fixture
import com.marcellogalhardo.fixture.nextListOf
import com.nhaarman.mockitokotlin2.*
import com.travelplanner.api.LocationInfoApiService
import com.travelplanner.api.TravelApiService
import com.travelplanner.models.Location
import com.travelplanner.ui.RxImmediateSchedulerRule
import io.reactivex.Scheduler
import io.reactivex.Single
import io.reactivex.android.plugins.RxAndroidPlugins
import io.reactivex.plugins.RxJavaPlugins
import io.reactivex.schedulers.Schedulers
import org.junit.BeforeClass
import org.junit.Rule
import org.junit.Test



class NewTravelViewModelTest {
    @Rule
    @JvmField var testSchedulerRule = RxImmediateSchedulerRule()

    private val fixture = Fixture {  }

    private val travelApiService = mock<TravelApiService> {  }
    private val locationInfoApiService = mock<LocationInfoApiService> {  }

    private val viewModel = NewTravelViewModel(travelApiService, locationInfoApiService)
    companion object {
        @BeforeClass
        @JvmStatic
        fun setupClass() {
            RxJavaPlugins.setIoSchedulerHandler { _ -> Schedulers.trampoline() }
            RxJavaPlugins.setInitIoSchedulerHandler { _ -> Schedulers.trampoline() }
            RxAndroidPlugins.setInitMainThreadSchedulerHandler { _ -> Schedulers.trampoline() }
            RxAndroidPlugins.setMainThreadSchedulerHandler { _ -> Schedulers.trampoline() }
        }
    }


    @Test
    fun getLocations_shouldReturnLocations() {
        val city = "city1"
        val locations = fixture.nextListOf<Location>(3)
        whenever(locationInfoApiService.getLocation(any())).thenReturn(Single.just(locations))

        viewModel.getLocations(city)

        verify(locationInfoApiService).getLocation(eq(city))
        assertThat(viewModel.locations.value).isEqualTo(locations)
    }
}