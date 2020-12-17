package com.travelplanner.ui.dayPlan

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.DayPlan
import com.travelplanner.ui.newTravel.showDatePickerDialog
import java.time.LocalDate
import java.time.LocalTime
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class  DayPlanFragment : Fragment() {

    lateinit var viewModel: DayPlanViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_day_plan, container, false)
        viewModel =
            ViewModelProvider(this).get(DayPlanViewModel::class.java)
        var travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        var cityName = activity?.intent?.getStringExtra(EXTRA_CITY_NAME)
        travelId?.let {
            viewModel.setTravelId(it)
        }
        val formatterD = DateTimeFormatter.ofLocalizedDate(FormatStyle.SHORT)
        val formatterDate = DateTimeFormatter.ISO_DATE

        val noSavedPlan = v.findViewById<LinearLayout>(R.id.no_saved_day_plan)
        val startDate = v.findViewById<TextView>(R.id.day_plan_start_date)
        var startDateValue: String? = null
        val startDateButton = v.findViewById<Button>(R.id.new_day_plan_start_date_button)
        val startTime = v.findViewById<TextView>(R.id.day_plan_start_time)
        var startTimeValue: String? = null
        val startTimeButton = v.findViewById<Button>(R.id.new_day_plan_start_time_button)
        val endDate = v.findViewById<TextView>(R.id.day_plan_end_date)
        var endDateValue: String? = null
        val endDateButton = v.findViewById<Button>(R.id.day_plan_end_date_button)
        val endTime = v.findViewById<TextView>(R.id.day_plan_end_time)
        var endTimeValue: String? = null
        val endTimeButton = v.findViewById<Button>(R.id.day_plan_end_time_button)
        val searchButton = v.findViewById<Button>(R.id.search_day_plan_button)

        startDateButton.setOnClickListener{
            context?.showDayPlanDatePickerDialog { localDate ->
                startDateValue = localDate.format(formatterDate).toString()
                startDate.text = localDate.format(formatterD)
            }
        }

        startTimeButton.setOnClickListener{
            context?.showDayPlanTimePickerDialog { hour, minute ->
                startTimeValue = formatHour(hour, minute)
                startTime.text = formatHour(hour, minute)
            }
        }

        endDateButton.setOnClickListener{
            context?.showDayPlanDatePickerDialog { localDate ->
                endDateValue = localDate.format(formatterDate).toString()
                endDate.text = localDate.format(formatterD)
            }
        }

        endTimeButton.setOnClickListener{
            context?.showDayPlanTimePickerDialog { hour, minute  ->
                endTimeValue = formatHour(hour, minute)
                endTime.text = formatHour(hour, minute)
            }
        }

        searchButton.setOnClickListener {
            viewModel.addDayPlan(cityName!!, startTimeValue!!, endTimeValue!!, startDateValue!!, endDateValue!!, travelId!!)
        }

        val recycler = v.findViewById<RecyclerView>(R.id.day_plan_recycler)
        recycler.visibility = View.GONE
        val adapter = DayPlanAdapter(travelId){
            viewModel.addToFavourites(it, travelId)
        }
        viewModel.liked.observe(viewLifecycleOwner, Observer {
            Toast.makeText(context, "Point added to list", Toast.LENGTH_SHORT).show()
        })
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.dayPlan.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()){
                adapter.setData(it.first().days)
                noSavedPlan.visibility = View.GONE
                recycler.visibility = View.VISIBLE
            }
        })
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
        val EXTRA_CITY_NAME = "city_name"
    }

    fun formatHour(h: Int, m: Int): String {
        return "${if(h < 10) "0$h" else "$h"}:${if(m < 10) "0$m" else "$m"}"
    }
}