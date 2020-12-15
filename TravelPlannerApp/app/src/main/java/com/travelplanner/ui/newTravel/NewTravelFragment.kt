package com.travelplanner.ui.newTravel

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R
import com.travelplanner.models.Location
import com.travelplanner.models.Travel
import com.travelplanner.models.TravelDestination
import com.travelplanner.models.TravelParticipants
import com.travelplanner.ui.flight.search.showFlightDatePickerDialog
import com.travelplanner.ui.location.showLocationDialog
import com.travelplanner.ui.travel.TravelFragment
import com.travelplanner.ui.travelDetails.TravelDetailsActivity
import org.w3c.dom.Text
import java.time.LocalDate
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class NewTravelFragment : Fragment() {

    private lateinit var newTravelViewModel: NewTravelViewModel

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        newTravelViewModel =
                ViewModelProvider(this).get(NewTravelViewModel::class.java)
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.SHORT)
        val root = inflater.inflate(R.layout.fragment_new_travel, container, false)
        val locationInput = root.findViewById<EditText>(R.id.new_travel_location)
        val searchLocationButton = root.findViewById<Button>(R.id.new_travel_location_search_button)
        val startDate = root.findViewById<TextView>(R.id.new_travel_start_date)
        val startDateButton = root.findViewById<Button>(R.id.new_travel_start_date_button)
        val endDate = root.findViewById<TextView>(R.id.new_travel_end_date)
        val endDateButton = root.findViewById<Button>(R.id.new_travel_end_date_button)
        val adultsNumber = root.findViewById<EditText>(R.id.create_travel_adults)
        val childrenNumber = root.findViewById<EditText>(R.id.create_travel_children)
        val childrenAges = root.findViewById<EditText>(R.id.create_travel_children_ages)
        val addTravelButton = root.findViewById<Button>(R.id.create_travel_add_travel_button)

        var location: Location? = null
        var startDateValue: LocalDate? = null
        var endDateValue: LocalDate? = null
        searchLocationButton.setOnClickListener{
            context?.showLocationDialog(locationInput.text.toString()){
                location = it
                val locationName = it.name + ", " + it.countryId
                locationInput.setText(locationName)
            }
        }
        startDateButton.setOnClickListener{
            context?.showFlightDatePickerDialog { localDate ->
                startDateValue = localDate
                startDate.text = localDate.format(formatter)
            }
        }
        endDateButton.setOnClickListener{
            context?.showFlightDatePickerDialog { localDate ->
                endDateValue = localDate
                endDate.text = localDate.format(formatter)
            }
        }

        addTravelButton.setOnClickListener {
            var children: Int = 0
            if(childrenNumber.text.isNotEmpty()) children= childrenNumber.text.toString().toInt()
            val adults = adultsNumber.text.toString().toInt()
            val travelDestination = TravelDestination(location?.name!!, location?.countryId!!)
            val participants = TravelParticipants(children, null, adults)
            val travel = Travel(null, startDateValue!!, endDateValue!!, participants, travelDestination, null)
            newTravelViewModel.postTravel(travel)
        }

        newTravelViewModel.toastError.observe(viewLifecycleOwner, Observer {p ->
            Toast.makeText(context, p, Toast.LENGTH_SHORT).show()
        })

        newTravelViewModel.travel.observe(viewLifecycleOwner, Observer {p ->
            newTravelViewModel.postLocation(location!!, p?.travelId!!)
            val intent = Intent(activity, TravelDetailsActivity::class.java)
            intent.putExtra(TravelFragment.EXTRA_TRAVEL, p)
            activity?.startActivity(intent)
        })
        return root
    }
}